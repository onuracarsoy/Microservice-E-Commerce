namespace Shop.ServiceDistribute.Dtos.CatalogDtos.ContactDtos
{
    public class UpdateContactDto
    {
        public string ContactID { get; set; }

        public string ContactNameSurname { get; set; }

        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }

        public bool ContactIsRead { get; set; }

        public DateTime ContactSendDate { get; set; }
    }
}
