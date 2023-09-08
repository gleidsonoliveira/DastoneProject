using Dastone.Domain.Entity.Base;

namespace Dastone.Domain.Entity
{
    public class Client : EntityBase
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Endereço do cliente
        /// </summary>
        public string Address { get; set; }

        // <summary>
        /// número do endereço do cliente
        /// </summary>
        public string AddressNumber { get; set; }

        // <summary>
        /// Ecep
        /// </summary>
        public string ZipCode { get; set; }

        // <summary>
        /// Bairro
        /// </summary>
        public string neighborhood { get; set; }
    }
}
