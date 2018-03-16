using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Plexo
{
    [ServiceContract]
    public interface IPaymentGateway
    {

        #region Operations
        
        [OperationContract]
        [WebInvoke(UriTemplate = "Auth", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Session>> Authorize(Authorization authorization);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operation/Purchase", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> Purchase(PaymentRequest payment);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operation/Cancel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> Cancel(CancelRequest payment);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operation/StartReserve", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> StartReserve(ReserveRequest payment);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operation/EndReserve", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> EndReserve(Reserve reserve);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operation/Status", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> Status(Reference payment);

        #endregion

        #region Instruments
        
        [OperationContract]
        [WebInvoke(UriTemplate = "Instruments", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<List<PaymentInstrument>>> GetInstruments(AuthorizationInfo info);

        [OperationContract]
        [WebInvoke(UriTemplate = "Instruments/Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse> DeleteInstrument(DeleteInstrumentRequest info);

        [OperationContract]
        [WebInvoke(UriTemplate = "Instruments/Bank", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<PaymentInstrument>> CreateBankInstrument(CreateBankInstrumentRequest request);


        #endregion

        #region Issuers

        [OperationContract]
        [WebGet(UriTemplate = "Issuer", ResponseFormat = WebMessageFormat.Json)]
        Task<ServerResponse<List<IssuerInfo>>> GetSupportedIssuers();

        #endregion

        #region Commerces

        [OperationContract]
        [WebGet(UriTemplate = "Commerce", ResponseFormat = WebMessageFormat.Json)]
        Task<ServerResponse<List<Commerce>>> GetCommerces();


        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Commerce>> AddCommerce(CommerceRequest commerce);

        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Modify", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Commerce>> ModifyCommerce(CommerceModifyRequest commerce);

        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse> DeleteCommerce(CommerceIdRequest commerce);
        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/SetDefault", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse> SetDefaultCommerce(CommerceIdRequest commerce);

        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Issuer", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<List<IssuerData>>> GetCommerceIssuers(CommerceIdRequest commerce);

        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Issuer/Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<IssuerData>> AddIssuerCommerce(IssuerData commerce);

        [OperationContract]
        [WebInvoke(UriTemplate = "Commerce/Issuer/Delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse> DeleteIssuerCommerce(CommerceIssuerIdRequest commerce);

        #endregion
        
        #region TransactionInfo

        [OperationContract]
        [WebInvoke(UriTemplate = "Transactions", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<TransactionCursor>> ObtainTransactions(TransactionQuery query);

        [OperationContract]
        [WebInvoke(UriTemplate = "Transactions/CSV", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<string>> ObtainCSVTransactions(TransactionQuery query);

        #endregion

        #region VerificationCodes

        [OperationContract]
        [WebInvoke(UriTemplate = "Code", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> CodeAction(CodeRequest request);

        #endregion

        #region Backoffice Cancelation

        [OperationContract]
        [WebInvoke(UriTemplate = "Backoffice/Cancel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Task<ServerResponse<Transaction>> BackofficeCancel(string transactionid);

        #endregion
    }
}
