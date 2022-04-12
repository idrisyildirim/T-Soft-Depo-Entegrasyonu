using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;


namespace VCLClasses {
	public class TStringListError : ApplicationException {
		public TStringListError(string AMessage) : base(AMessage) {
		}
	}
	
	[Flags]
	enum TStringsDefined {
		Delimiter = 0x1,
		QuoteChar = 0x2,
		NameValueSeparator = 0x4
	};
	
	public class TStringsEnumerator : Object, IEnumerator {
		private int FIndex = -1;
		private TStrings FStrings;
		
		internal TStringsEnumerator(TStrings AStrings) {
			FStrings = AStrings;
		}
		
		public Object Current {
			get { return FStrings[FIndex]; }
		}
		
		public bool MoveNext() {
			if (FIndex < FStrings.Count)
				++FIndex;
				
			return FIndex < FStrings.Count;
		}
		
		public void Reset() {
			FIndex = -1;
		}
	};

	public abstract class TStrings : Object, ICloneable, IEnumerable, ICollection, IList {
	// private
		private TStringsDefined FDefined;
		private char FDelimiter = ',';
		private char FQuoteChar = '"';
		private char FNameValueSeparator = '=';
		internal int FUpdateCount = 0;
		
		private string GetCommaText() {
			TStringsDefined oldDefined = FDefined;
			char oldDelim = FDelimiter;
			char oldQuote = FQuoteChar;
			FDelimiter = ',';
			FQuoteChar = '"';
			try {
				return GetDelimitedText();
			} finally {
				FDelimiter = oldDelim;
				FQuoteChar = oldQuote;
				FDefined = oldDefined;
			}
		}
		
		static private string AnsiQuotedStr(string AValue, string AQuote) {
			if (AValue.StartsWith(AQuote)) {
				if (AValue.EndsWith(AQuote))
					return AValue;
				else 
					return AValue + AQuote;
			} else {
				if (AValue.EndsWith(AQuote))
					return AQuote + AValue;
				else
					return AQuote + AValue + AQuote;
			}
		}
		
		private string GetDelimitedText() {
			int count = GetCount();
			string result;
			
			if (count == 1 && Get(0) == String.Empty)
				result = new string(QuoteChar, 1);
			else {
				result = "";
				for (int i = 0; i < Count; ++i) {
					string s = Get(i);
					int p = 0;
					while (p < s.Length && s[p] > ' ' && s[p] != QuoteChar && 
						s[p] != Delimiter)
						++p;
					if (p < s.Length && s[p] != '\0')
						s = AnsiQuotedStr(s, "" + QuoteChar);
					result = result + s + Delimiter;
				}
			}
			return result.Substring(0, result.Length - 1);
		}
		
		private string GetName(int Index) {
			return ExtractName(Get(Index));
		}
		
		private string GetValue(string AName) {
			int i = IndexOfName(AName);
			if (i >= 0)
				return Get(i).Substring(AName.Length + 1);
			else
				return String.Empty;
		}
		
		private void ReadData(TextReader AReader) {
			BeginUpdate();
			try {
				Clear();
				String s;
				while ((s = AReader.ReadLine()) != null)
					Add(s);
			} finally {
				EndUpdate();
			}
		}
		
		private void SetCommaText(string AValue) {
			FDelimiter = ',';
			FQuoteChar = '"';
			SetDelimitedText(AValue);
		}
		
		private static string AnsiExtractQuotedStr(string AValue, char AQuote) {
			int i = AValue.IndexOf(AQuote);
			return i != -1 ? AValue.Substring(0, i) : AValue;
		}
		
		private void SetDelimitedText(string AValue) {
			BeginUpdate();
			try {
				string s;
				
				Clear();
				int p = 0;
				while (p < AValue.Length && AValue[p] > '\0' && AValue[p] <= ' ')
					++p;
				
				while (p < AValue.Length) {
					if (AValue[p] == QuoteChar)
						s = AnsiExtractQuotedStr(AValue.Substring(p), QuoteChar);
					else {
						int p1 = p;
						while (p < AValue.Length && AValue[p] > ' ' && AValue[p] != Delimiter)
							++p;
						s = AValue.Substring(p1, p - p1);
					}
					Add(s);
					
					while (p < AValue.Length && AValue[p] > '\0' && AValue[p] <= ' ')
						++p;
						
					if (p < AValue.Length && AValue[p] == Delimiter) {
						if (p + 1 >= AValue.Length)
							Add(String.Empty);
							
						do ++p;
						while (p < AValue.Length && AValue[p] > '\0' && AValue[p] <= ' ');
					}
				}
			} finally {
				EndUpdate();
			}
		}
		
		private void SetValue(string AName, string AValue) {
			int i = IndexOfName(AName);
			if (AValue != String.Empty) {
				if (i < 0)
					i = Add(String.Empty);
				Put(i, AName + NameValueSeparator + AValue);
			} else 
				if (i >= 0)
					Delete(i);
		}
		
		private void WriteData(TextWriter AWriter) {
			for (int i = 0; i < Count; ++i)
				AWriter.WriteLine(Get(i));
		}
		
		private char GetDelimiter() {
			if ((FDefined & TStringsDefined.Delimiter) == 0)
				Delimiter = ',';
				
			return FDelimiter;
		}
		
		private void SetDelimiter(char AValue) {
			if (FDelimiter != AValue || (FDefined & TStringsDefined.Delimiter) == 0) {
				FDefined |= TStringsDefined.Delimiter;
				FDelimiter = AValue;
			}
		}
		
		private char GetQuoteChar() {
			if ((FDefined & TStringsDefined.QuoteChar) == 0)
				QuoteChar = '"';
				
			return FQuoteChar;
		}
		
		private void SetQuoteChar(char AValue) {
			if (FQuoteChar != AValue || (FDefined & TStringsDefined.QuoteChar) == 0) {
				FDefined |= TStringsDefined.QuoteChar;
				FQuoteChar = AValue;
			}
		}
		
		private char GetNameValueSeparator() {
			if ((FDefined & TStringsDefined.NameValueSeparator) == 0)
				QuoteChar = '"';
				
			return FNameValueSeparator;
		}
		
		private void SetNameValueSeparator(char AValue) {
			if (FQuoteChar != AValue || (FDefined & TStringsDefined.NameValueSeparator) == 0) {
				FDefined |= TStringsDefined.NameValueSeparator;
				FNameValueSeparator = AValue;
			}
		}
		
		private string GetValueFromIndex(int AIndex) {
			return AIndex > 0 ? 
				Get(AIndex).Substring(Names(AIndex).Length + 2) : 
				String.Empty;
		}
		
		private void SetValueFromIndex(int AIndex, string AValue) {
			if (AValue != String.Empty) {
				if (AIndex < 0)
					AIndex = Add(String.Empty);
				Put(AIndex, Names(AIndex) + NameValueSeparator + AValue);
			} else
				if (AIndex >= 0)
					Delete(AIndex);
		}
	
	// protected

		protected void Error(string Msg, int Data) {
			throw new TStringListError(string.Format(Msg, Data));
		}
		
		protected string ExtractName(string s) {
			int p = s.IndexOf(NameValueSeparator);
			return p > 0 ? s.Substring(0, p) : "";
		}
		
		protected abstract string Get(int Index);

		protected virtual int GetCapacity() {
			return Count;
		}
		
		protected abstract int GetCount();
		
		protected virtual object GetObject(int Index) {
			return null;
		}
		
		protected virtual string GetTextStr() {
			string NL = "\r\n";
			StringBuilder sb = new StringBuilder();
			int count = GetCount();
			
			for (int i = 0; i < count; ++i)
				sb.Append(Get(i) + NL);
				
			return sb.ToString();
		}
		
		protected virtual void Put(int AIndex, string AValue) {
			object dummy = GetObject(AIndex);
			Delete(AIndex);
			InsertObject(AIndex, AValue, dummy);
		}
		
		protected virtual void PutObject(int AIndex, object AObject) {
		}
		
		protected virtual void SetCapacity(int ACapacity) {
		}
		
		protected virtual void SetTextStr(string AText) {
			BeginUpdate();
			try {
				Clear();
				string NL = "\r\n";
				for (int i = 0; i != -1 && i < AText.Length;) {
					int oi = i;
					i = AText.IndexOf(NL, i);
					if (i != -1)
						Add(AText.Substring(oi, i - oi));
					else {
						Add(AText.Substring(oi));
						break;
					}
					i += NL.Length;
				}
			} finally {
				EndUpdate();
			}
		}
		
		protected virtual void SetUpdateState(bool AUpdating) {
		}
		
		protected int UpdateCount {
			get { return FUpdateCount; }
		}
		
		protected virtual int CompareStrings(string s1, string s2) {
			return s1.CompareTo(s2);
		}
		
	// public interface
		// ICloneable
		public abstract object Clone();
		
		// IEnumerable
		public IEnumerator GetEnumerator() {
			return new TStringsEnumerator(this);
		}
		
		// ICollection
		public bool IsSynchronized {
			get { return false; }
		}
		
		public object SyncRoot {
			get { return this; }
		}
		
		public abstract void CopyTo(Array a, int i);
		
		// IList
		int IList.Add(object AObject) {
			int result = Count;
			Add((string) AObject);
			return result;
		}
		
		bool IList.Contains(object AObject) {
			return IndexOf((string)AObject) != -1;
		}
		
		void IList.Insert(int AIndex, object AObject) {
			Insert(AIndex, (string)AObject);
		}
		
		bool IList.IsFixedSize {
			get { return false; }
		}
		
		bool IList.IsReadOnly {
			get { return false; }
		}
		
		void IList.Remove(object AObject) {
			Delete(IndexOf((string)AObject));
		}
		
		void IList.RemoveAt(int AIndex) {
			Delete(AIndex);
		}
		
		int IList.IndexOf(object AObject) {
			return IndexOf((string)AObject);
		}
		
		object IList.this[int AIndex] {
			get { return Get(AIndex); }
			set { Put(AIndex, (string)value); }
		}
		
		// Delphi
		public override string ToString() {
			return Text;
		}
		
		public virtual int Add(string s) {
			int result = GetCount();
			Insert(result, s);
			return result;
		}
		public virtual int AddObject(string s, object AObject) {
			int result = Add(s);
			PutObject(result, AObject);
			return result;
		}
		
		public void Append(string s) {
			Add(s);
		}
		
		public virtual void AddStrings(TStrings AStrings) {
			BeginUpdate();
			try {
				for (int i = 0; i < AStrings.Count; ++i)
					AddObject(AStrings[i], AStrings.Objects(i));
			} finally {
				EndUpdate();
			}
		}
		
		public virtual void Assign(TStrings Source) {
			BeginUpdate();
			try {
				Clear();
				FDefined = Source.FDefined;
				FNameValueSeparator = Source.FNameValueSeparator;
				FQuoteChar = Source.FQuoteChar;
				FDelimiter = Source.FDelimiter;
				AddStrings(Source);
			} finally {
				EndUpdate();
			}
		}
		
		public void BeginUpdate() {
			if (FUpdateCount == 0)
				SetUpdateState(true);
			
			++FUpdateCount;
		}
		
		public abstract void Clear();
		public abstract void Delete(int Index);
		
		public void EndUpdate() {
			--FUpdateCount;
			if (FUpdateCount == 0)
				SetUpdateState(false);
		}
		
		public override bool Equals(object o) {
			return o is TStrings ? Equals(o as TStrings) : false;
		}
		
		public bool Equals(TStrings AStrings) {
			int count = AStrings.GetCount();
			if (count != AStrings.GetCount())
				return false;
			
			for (int i = 0; i < count; ++i)
				if (Get(i) != AStrings.Get(i))
					return false;
		
			return true;
		}
		
		public override int GetHashCode() {
			return base.GetHashCode();
		}
		
		public static bool operator ==(TStrings S1, TStrings S2) {
			return S1.Equals(S2);
		}
		
		public static bool operator !=(TStrings S1, TStrings S2) {
			return !S1.Equals(S2);
		}
		
		public virtual void Exchange(int AIndex1, int AIndex2) {
			BeginUpdate();
			try {
				String dummystr = Strings(AIndex1);
				object dummyobj = Objects(AIndex1);
				Strings(AIndex1, Strings(AIndex2));
				Objects(AIndex1, Objects(AIndex2));
				Strings(AIndex2, dummystr);
				Objects(AIndex2, dummyobj);
			} finally {
				EndUpdate();
			}
		}
		
		public virtual string GetText() {
			return GetTextStr();
		}
		
		public virtual int IndexOf(string AValue) {
			for (int i = 0; i < Count; ++i)
				if (CompareStrings(AValue, Get(i)) == 0)
					return i;
					
			return -1;
		}
		
		public virtual int IndexOfName(string AName) {
			for (int i = 0; i < Count; ++i) {
				string S = Get(i);
				int P = S.IndexOf(NameValueSeparator);
				if (P > 0 && S.Substring(0, P) == AName)
					return i;
			}
			
			return -1;
		}
		
		public virtual int IndexOfObject(object AObject) {
			for (int i = 0; i < Count; ++i)
				if (GetObject(i) == AObject)
					return i;
			
			return -1;
		}

		public abstract void Insert(int AIndex, string AValue);
		
		public virtual void InsertObject(int AIndex, string AValue, object AObject) {
			Insert(AIndex, AValue);
			PutObject(AIndex, AObject);
		}
		
		public virtual void LoadFromFile(string AFileName) {
			using (Stream s = new FileStream(AFileName, FileMode.Open, 
				FileAccess.Read, FileShare.Read))
				LoadFromStream(s);
		}
		
		public virtual void LoadFromStream(System.IO.Stream AStream) {
			BeginUpdate();
			try {
				char[] b = new char[AStream.Length - AStream.Position];
				new StreamReader(AStream).Read(b, 0, b.Length);
				SetTextStr(new string(b));
			} finally {
				EndUpdate();
			}
		}

		public virtual void Move(int CurIndex, int NewIndex) {
			if (CurIndex != NewIndex) {
				BeginUpdate();
				try {
					string dummystr = Get(CurIndex);
					object dummyobj = GetObject(CurIndex);
					Delete(CurIndex);
					InsertObject(NewIndex, dummystr, dummyobj);
				} finally {
					EndUpdate();
				}
			}
		}
		
		public virtual void SaveToFile(string AFileName) {
			using (Stream s = new FileStream(AFileName, FileMode.Create,
				FileAccess.Write, FileShare.None))
				SaveToStream(s);
		}
		
		public virtual void SaveToStream(Stream AStream) {
			using (StreamWriter sw = new StreamWriter(AStream))
				sw.Write(GetTextStr());
		}
		
		public virtual void SetText(string AText) {
			SetTextStr(AText);
		}
		
		public int Capacity {
			get { return GetCapacity(); }
			set { SetCapacity(value); }
		}
		
		public String CommaText {
			get { return GetCommaText(); }
			set { SetCommaText(value); }
		}
		
		public int Count {
			get { return GetCount(); }
		}
		
		public char Delimiter {
			get { return GetDelimiter(); }
			set { SetDelimiter(value); }
		}
		
		public String DelimitedText {
			get { return GetDelimitedText(); }
			set { SetDelimitedText(value); }
		}
		
		public String Names(int AIndex) {
			return GetName(AIndex);
		}
		
		public object Objects(int AIndex) {
			return GetObject(AIndex);
		}
		
		public void Objects(int AIndex, object AValue) {
			PutObject(AIndex, AValue);
		}
		
		public char QuoteChar {
			get { return GetQuoteChar(); }
			set { SetQuoteChar(value); }
		}
		
		public string Values(string AName) {
			return GetValue(AName);
		}
		
		public void Values(string AName, string AValue) {
			SetValue(AName, AValue);
		}
		
		public string ValueFromIndex(int AIndex) {
			return GetValueFromIndex(AIndex);
		}
		
		public void ValueFromIndex(int AIndex, string AValue) {
			SetValueFromIndex(AIndex, AValue);
		}
		
		public char NameValueSeparator {
			get { return GetNameValueSeparator(); }
			set { SetNameValueSeparator(value); }
		}
		
		public string Strings(int AIndex) {
			return Get(AIndex);
		}
		
		public void Strings(int AIndex, string AValue) {
			Put(AIndex, AValue);
		}
		
		public string this[int AIndex] {
			get { return Get(AIndex); }
			set { Put(AIndex, value); }
		}
		
		public string Text {
			get { return GetTextStr(); }
			set { SetTextStr(value); }
		}
	}
}
