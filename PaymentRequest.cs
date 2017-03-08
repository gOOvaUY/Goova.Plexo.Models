using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Goova.Plexo
{
    [DataContract]
    public class PaymentRequest 
    {
        [DataMember]
        public string ClientReferenceId { get; set; }
        [DataMember]
        public PaymentInstrumentInput PaymentInstrumentInput { get; set; }
        [DataMember]
        public List<Item> Items { get; set; }
        [DataMember]
        public int CurrencyId { get; set; }
        [DataMember]
        public int Installments { get; set; }
        [DataMember]
        public FinancialInclusion FinancialInclusion { get; set; }
        [DataMember]
        public string OptionalPointOfSale { get; set; }
        [DataMember]
        public string OptionalMetadata { get; set; }
    }
}