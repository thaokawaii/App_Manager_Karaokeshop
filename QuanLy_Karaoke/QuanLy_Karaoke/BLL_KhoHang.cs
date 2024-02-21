using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Karaoke
{
    public class BLL_KhoHang
    {
        ConnectDB c = new ConnectDB();
        public bool Check_txtFind(string text)
        {
            if(Check_NameProduct(text)==false)
            {
                MessageBox.Show("Chuỗi sai định dạng");
                return false;
            }    
            for (int i = 0; i < text.Length; i++)
            {

                if (char.IsDigit(text[i]) != true && char.IsLetter(text[i]) != true)
                {
                    MessageBox.Show("Không được chứa kí tự đặc biệt");
                    return false;
                }
            }
            return true;
        }
        public bool Check_txtQuantity(string text)
        {

            if (text == null)
            {
                return false;
            }
            if (int.Parse(text) <= 0 || int.Parse(text) > 1000000)
            {
                return false;
            }


            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) != true)
                {
                    return false;
                }
               
            }
            return true;
        }
        public bool Check_txtPrice(string text)
        {

            if (text == null)
            {
                return false;
            }

            if (int.Parse(text) <= 0 || int.Parse(text) > 1000000)
            {
                return false;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) != true)
                {
                    return false;

                }

            }
            return true;

        }

        public bool Check_NameProduct(string text)
        {

            if (text == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                return false; 
            }

          
            bool isUnicodeNormalized = IsUnicodeNormalized(text);

           
            bool isWhitespaceNormalized = IsWhitespaceNormalized(text);


            return isUnicodeNormalized && isWhitespaceNormalized;
        }
        static bool IsUnicodeNormalized(string input)
        {
           

            string pattern = @"[^a-zA-Z0-9\s]";
            return !Regex.IsMatch(input, pattern);
        }

        static bool IsWhitespaceNormalized(string input)
        {
            
            return input.Trim() == input;
        }
        public bool ThemSP(string ten,string soluong,string gia,string masp,string mamh,string dvt)
        {
          
                if (Check_NameProduct(ten)&& Check_txtPrice(gia)&&Check_txtQuantity(soluong)&& masp!=null&&mamh!=null&&dvt!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
         
        }
        public bool KiemTraKhoa(string ma)
        {

           string kt = "SELECT COUNT(*) FROM MATHANG WHERE  MAMH='" + ma + "'";
          
            object M = c.trave(kt);
            string p = M.ToString();
            if(p==null)
            {
                return false;
            }    
            return true;
        }
        public bool check_update(string mamh,string maloai,string gia,string dvt,string soluong,string tenhang)
        {
            if (Check_NameProduct(tenhang) && Check_txtPrice(gia) && Check_txtQuantity(soluong) && maloai != null && mamh != null && dvt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
