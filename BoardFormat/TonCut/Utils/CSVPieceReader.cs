using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TonCut
{
    public class CSVPieceReader
    {
        public string FilePath { get; set; }

        public CSVPieceReader()
        {

            FilePath = @"c:\Users\mateu\source\repos\TonCut\TonCut\piece_list.csv";
        }

        public IEnumerable<Piece> CreatePiece() 
        {
            using (TextFieldParser parser = new TextFieldParser(FilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                int count = 0;
                while (!parser.EndOfData)
                {

                    string[] fields = parser.ReadFields();
                    if (count > 0)
                    {
                        yield return new Piece(
                            id: Convert.ToInt32(fields[0]), materialId: Convert.ToInt32(fields[1]),
                            identifier: "", description: "", length: Convert.ToInt32(fields[2]), width: Convert.ToInt32(fields[3]),
                            shapeType: "none", quantity: Convert.ToInt32(fields[4]), structure:
                            fields[5], priority: "normal", surplus: 0, margin: 0,
                            veneers: new Veneers(leftVeneerId: null, rightVeneerId: null, topVeneerId: null, bottomVeneerId: null));
                    }
                    count++;
                }
            }

        }

    }
}
