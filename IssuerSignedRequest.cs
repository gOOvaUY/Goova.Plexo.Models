using System.Runtime.Serialization;

namespace Plexo
{
    [DataContract]
    public class IssuerSignedRequest<T> : SignedObject<IssuerRequest<T>> { }

    [DataContract]
    public class IssuerSignedRequest : SignedObject<IssuerRequest> { }


}