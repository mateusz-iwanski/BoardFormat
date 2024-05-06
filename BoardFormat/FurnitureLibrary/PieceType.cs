using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.FurnitureLibrary
{
    public enum PieceType
    {
        TopWreath,          // górny wienie
        TopWreathBar,       // górny wieniec listwa
        BottomWreath,       // dolny wieniec
        Left,               // lewy
        Right,              // prawy
        Front,              // przód/front
        Back,               // tył/plecy
        Shelf,              // polka
        DrawerLeft,         // szuflada
        DrawerRight,        // szuflada prawy bok
        DrawerBottom,       // szuflada dno
        DrawerFront,        // szuflada front
        DrawerBack,         // szuflada tył
        Partition,          // przegroda
        Leg,                // noga
        Panel,              // panel
        Plinth,             // cokoł
        Other,              // inne
    }
}
