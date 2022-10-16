namespace Web_Api_Modul_34.Contracts.Home
{
    public class InfoResponse
    {
        public int FloorAmount { get; set; }
        public string Telephone { get; set; }
        public string Heating { get; set; }
        public int CurrentVolts { get; set; }
        public bool GasConnected { get; set; }
        public int Area { get; set; }
        public string Material { get; set; }
        public AddressInfo AddressInfo { get; set; }


    }
}
