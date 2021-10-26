namespace ProdutoCrud.Utils
{
    public static class StringExtensions
    {
        public static string PrimeiraMaiuscula(this string strString)
        {

            string strResult = "";

            if (strString?.Length > 0)
            {
                strResult += strString.Substring(0, 1).ToUpper();

                strResult += strString[1..].ToLower();
            }
            return strResult;
        }
    }
}
