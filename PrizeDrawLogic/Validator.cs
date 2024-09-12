namespace PrizeDrawLogic
{
    public class Validator(IDatabase db)
    {
        private IDatabase db = db;

        public async Task<(bool, string)> IsValidSubmission(string serialNumber)
        {
            bool isValid = await db.IsValidSerialNumber(serialNumber);
            if (!isValid)
            {
                return (false, "Invalid serial number");
            }
            bool serialNumberUsedMoreThanOnce = await db.GetUsage(serialNumber) >= 2;
            if (serialNumberUsedMoreThanOnce)
            {
                return (false, "Serial number already used twice");
            }
            return (true, "");
        }

    }
}
