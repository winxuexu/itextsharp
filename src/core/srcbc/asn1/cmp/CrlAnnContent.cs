using System;

using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.Asn1.Cmp
{
	[Obsolete("For internal use only. If you want to use iText, please use a dependency on iText 7. ")]
    public class CrlAnnContent
		: Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private CrlAnnContent(Asn1Sequence seq)
		{
			content = seq;
		}

		public static CrlAnnContent GetInstance(object obj)
		{
			if (obj is CrlAnnContent)
				return (CrlAnnContent)obj;

			if (obj is Asn1Sequence)
				return new CrlAnnContent((Asn1Sequence)obj);

			throw new ArgumentException("Invalid object: " + obj.GetType().Name, "obj");
		}

		public virtual CertificateList[] ToCertificateListArray()
		{
			CertificateList[] result = new CertificateList[content.Count];
			for (int i = 0; i != result.Length; ++ i)
			{
				result[i] = CertificateList.GetInstance(content[i]);
			}
			return result;
		}

		/**
		 * <pre>
		 * CrlAnnContent ::= SEQUENCE OF CertificateList
		 * </pre>
		 * @return a basic ASN.1 object representation.
		 */
		public override Asn1Object ToAsn1Object()
		{
			return content;
		}
	}
}
