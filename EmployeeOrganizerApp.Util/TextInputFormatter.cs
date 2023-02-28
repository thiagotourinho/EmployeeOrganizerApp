namespace EmployeeManager.Util
{
    public static class TextInputFormatter
    {

        public enum TypeString
        {
            Numero,
            Cnpj,
            Cpf,
            Data,
            Int,
            Cep,
            Telefone,
            DinheiroReal
        }

        /// <summary>
        /// Formats a certain string relying on the enum TypeString available options: Numero, Cnpj, Cpf, Data, Int, Cep, Telefone, DinheiroReal
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="tType"></param>
        /// <returns></returns>
        public static string MaskInputData(string Value, TypeString tType)
        {

            try
            {

                switch (tType)
                {

                    case TypeString.Cnpj:

                        return string.Format("{0}.{1}.{2}/{3}-{4}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3), Value.Substring(8, 4), Value.Substring(12, 2));

                    case TypeString.Cpf:

                        return string.Format("{0}.{1}.{2}-{3}", Value.Substring(0, 3), Value.Substring(3, 3), Value.Substring(6, 3), Value.Substring(9, 2));

                    case TypeString.Data:

                        if (Convert.ToDateTime(Value) == Convert.ToDateTime("1/1/1900"))

                            return string.Empty;

                        else

                            return Convert.ToDateTime(Value).ToString("dd/MM/yyyy");

                    case TypeString.Numero:

                        return Convert.ToDouble(Value).ToString("#,##0.00");

                    case TypeString.Int:

                        return Convert.ToInt64(Value).ToString("#,##0");

                    case TypeString.Cep:

                        return string.Format("{0}.{1}-{2}", Value.Substring(0, 2), Value.Substring(2, 3), Value.Substring(5, 3));

                    case TypeString.Telefone:

                        Value = Value.Replace("-", "").Replace(" ", "").Replace(".", "");
                        // 99 9999 9999 99 99999 9999
                        // 01 2345 6789
                        if (Value.Length == 11)
                        {
                            return string.Format("({0}) {1}-{2}", Value.Substring(0, 2), Value.Substring(2, 5), Value.Substring(7, 4));
                        }
                        else
                        {
                            return string.Format("({0}) {1}-{2}", Value.Substring(0, 2), Value.Substring(2, 4), Value.Substring(6, 4));
                        }

                    case TypeString.DinheiroReal:

                        return Convert.ToDouble(Value).ToString("C");

                    default:

                        return Value;

                }

            }

            catch
            {

                return Value;

            }

        }


    }
}
