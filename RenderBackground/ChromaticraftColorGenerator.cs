using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


public static class ChromaticraftColorGenerator
{
    public static Color GetColor(Rune rune)
    {
        switch (rune)
        {
            case Rune.Kuro:
                return Color.FromRgb(46, 46, 46);
            case Rune.Karmir:
                return Color.FromRgb(240, 30, 30);
            case Rune.Kijani:
                return Color.FromRgb(24, 134, 34);
            case Rune.Ruskea:
                return Color.FromRgb(122, 71, 39);
            case Rune.Nila:
                return Color.FromRgb(27, 56, 238);
            case Rune.Zambarau:
                return Color.FromRgb(143, 29, 225);
            case Rune.Vadali:
                return Color.FromRgb(29, 171, 193);
            case Rune.Argia:
                return Color.FromRgb(154, 154, 154);
            case Rune.Ykri:
                return Color.FromRgb(83, 83, 83);
            case Rune.Ruzova:
                return Color.FromRgb(244, 186, 208);
            case Rune.Asveste:
                return Color.FromRgb(33, 240, 29);
            case Rune.Kitrino:
                return Color.FromRgb(240, 238, 29);
            case Rune.Galazio:
                return Color.FromRgb(133, 205, 244);
            case Rune.Kurauri:
                return Color.FromRgb(236, 29, 215);
            case Rune.Portokali:
                return Color.FromRgb(250, 120, 30);
            case Rune.Tahara:
                return Color.FromRgb(245, 245, 245);
            default:
                return Color.FromRgb(0, 0, 0);
        }
    }
}
public enum Rune
{
    Kuro,
    Karmir,
    Kijani,
    Ruskea,
    Nila,
    Zambarau,
    Vadali,
    Argia,
    Ykri,
    Ruzova,
    Asveste,
    Kitrino,
    Galazio,
    Kurauri,
    Portokali,
    Tahara,
}

