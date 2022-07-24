using UnityEngine;
using UnityEngine.UI;

public class SuryongNameHandler : MonoBehaviour
{
    public Text _name;

    private void Start()
    {
        int select = UIFollowCharacter.select;

        switch (select)
        {
            case 1:
                _name.text = "±¹¾î±¹¹®¼ö·æ";
                break;
            case 2:
                _name.text = "¿µ¾î¿µ¹®¼ö·æ";
                break;
            case 3:
                _name.text = "µ¶ÀÏ¾î¹®¼ö·æ";
                break;
            case 4:
                _name.text = "ÇÁ¶û½º¾î¹®¼ö·æ";
                break;
            case 5:
                _name.text = "ÀÏº»¾î¹®¼ö·æ";
                break;
            case 6:
                _name.text = "Áß±¹¾î¹®¼ö·æ";
                break;
            case 7:
                _name.text = "»çÇÐ¼ö·æ";
                break;
            case 8:
                _name.text = "Á¤Ä¡¿Ü±³¼ö·æ";
                break;
            case 9:
                _name.text = "½É¸®¼ö·æ";
                break;
            case 10:
                _name.text = "Áö¸®¼ö·æ";
                break;
            case 11:
                _name.text = "°æÁ¦¼ö·æ";
                break;
            case 12:
                _name.text = "°æ¿µ¼ö·æ";
                break;
            case 13:
                _name.text = "¹ÌÄÄ¼ö·æ";
                break;
            case 14:
                _name.text = "¹ýÇÐ¼ö·æ";
                break;
            case 15:
                _name.text = "IT¼ö·æ";
                break;
            case 16:
                _name.text = "¼ö¸®Åë°è¼ö·æ";
                break;
            case 17:
                _name.text = "Åë°è¼ö·æ";
                break;
            case 18:
                _name.text = "È­ÇÐ¿¡³ÊÁö¼ö·æ";
                break;
            case 19:
                _name.text = "¼­ºñ½ºµðÀÚÀÎ¼ö·æ";
                break;
            case 20:
                _name.text = "À¶ÇÕº¸¾È¼ö·æ";
                break;
            case 21:
                _name.text = "ÄÄÇ»ÅÍ¼ö·æ";
                break;
            case 22:
                _name.text = "Á¤º¸½Ã½ºÅÛ¼ö·æ";
                break;
            case 23:
                _name.text = "Ã»Á¤À¶ÇÕ¿¡³ÊÁö¼ö·æ";
                break;
            case 24:
                _name.text = "¹ÙÀÌ¿À½ÄÇ°¼ö·æ";
                break;
            case 25:
                _name.text = "¹ÙÀÌ¿À»ý¸í¼ö·æ";
                break;
            case 26:
                _name.text = "°£È£¼ö·æ";
                break;
            case 27:
                _name.text = "¹ÙÀÌ¿À½Å¾àÀÇ°úÇÐ¼ö·æ";
                break;
            case 28:
                _name.text = "¹ÙÀÌ¿ÀÇï½º¼ö·æ";
                break;
            case 29:
                _name.text = "»çÈ¸º¹Áö¼ö·æ";
                break;
            case 30:
                _name.text = "½ºÆ÷Ã÷°úÇÐ¼ö·æ";
                break;
            case 31:
                _name.text = "AI¼ö·æ";
                break;
            case 32:
                _name.text = "±Û·Î¹úºñÁö´Ï½º¼ö·æ";
                break;
            case 33:
                _name.text = "ÀÇ·ù»ê¾÷¼ö·æ";
                break;
            case 34:
                _name.text = "ºäÆ¼»ê¾÷¼ö·æ";
                break;
            case 35:
                _name.text = "¼ÒºñÀÚ»ýÈ°¼ö·æ";
                break;
            case 36:
                _name.text = "±³À°¼ö·æ";
                break;
            case 37:
                _name.text = "»çÈ¸±³À°¼ö·æ";
                break;
            case 38:
                _name.text = "À±¸®±³À°¼ö·æ";
                break;
            case 39:
                _name.text = "ÇÑ¹®±³À°¼ö·æ";
                break;
            case 40:
                _name.text = "À¯¾Æ±³À°¼ö·æ";
                break;
            case 41:
                _name.text = "µ¿¾çÈ­¼ö·æ";
                break;
            case 42:
                _name.text = "¼­¾çÈ­¼ö·æ";
                break;
            case 43:
                _name.text = "Á¶¼Ò¼ö·æ";
                break;
            case 44:
                _name.text = "°ø¿¹¼ö·æ";
                break;
            case 45:
                _name.text = "»ê¾÷µðÀÚÀÎ¼ö·æ";
                break;
            case 46:
                _name.text = "¼º¾Ç¼ö·æ";
                break;
            case 47:
                _name.text = "±â¾Ç¼ö·æ";
                break;
            case 48:
                _name.text = "ÀÛ°î¼ö·æ";
                break;
            case 49:
                _name.text = "¹®È­¿¹¼ú°æ¿µ¼ö·æ";
                break;
            case 50:
                _name.text = "¹Ìµð¾î¿µ»ó¿¬±â¼ö·æ";
                break;
            case 51:
                _name.text = "Çö´ë½Ç¿ëÀ½¾Ç¼ö·æ";
                break;
            case 52:
                _name.text = "¹«¿ë¿¹¼ú¼ö·æ";
                break;
        }
    }
}
