namespace ProdutoCrud.Utils
{
    public static class StringExtensions
    {
        public static string PrimeiraMaiuscula(this string strString)
        {   
            if (!string.IsNullOrEmpty(strString))
            {
                return char.ToUpper(strString[0]) + strString.Substring(1);
            }

            return string.Empty;
        }
    }
}
