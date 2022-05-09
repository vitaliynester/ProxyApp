namespace ProxyApp.DTOs
{
    public class PatientAuthorizationRequest
    {
        public int ClinicId { get; set; }
        public int BranchId { get; set; }
        public string Barcode { get; set; }
        public PatientData Patient { get; set; }
    }

    public class PatientData
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
    }
}