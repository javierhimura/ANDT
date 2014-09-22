using System;
using System.IO;
using SourceGrid;

namespace Andi.Toolkit.utils
{
    public class LoadCurrentData
    {
        public static void WildEx4(int lenghtdata, Grid grid1, string[] pkmname, Stream a)
        {
            string[] data = new string[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i * 4;
                a.Read(temp, 0, 4);
                data[i] = pkmname[BitConverter.ToUInt32(temp, 0) - 1];
            }

            FillGrid.Build(grid1, lenghtdata);
            FillGrid.Fill(grid1, data);
        }

        public static vEnum.GameVer FindGameVersion(int index)
        {
            switch (index)
            {
                case 1:
                    return vEnum.GameVer.DP;
                case 2:
                    return vEnum.GameVer.PtHGSS;
                case 3:
                    return vEnum.GameVer.BW;
                case 4:
                    return vEnum.GameVer.BW2;
                case 5:
                    return vEnum.GameVer.XY;
                default:
                    return vEnum.GameVer.BW2;
            }
        }

        public static vEnum.GameFormat FindGameFormat(int index)
        {
            switch (index)
            {
                case 1:
                    return vEnum.GameFormat.gen4;
                case 2:
                    return vEnum.GameFormat.gen4;
                case 3:
                    return vEnum.GameFormat.gen5;
                case 4:
                    return vEnum.GameFormat.gen5;
                case 5:
                    return vEnum.GameFormat.gen6;
                default:
                    return vEnum.GameFormat.gen5;
            }
        }

        public static int FindGameId(int index)
        {
            switch (index)
            {
                case 1:
                    return 12;
                case 2:
                    return 14;
                case 3:
                    return 17;
                case 4:
                    return 21;
                case 5:
                    return 23;
                default:
                    return 21;
            }
        }

        public static int FindGameIdFromCount(int index)
        {
            switch (index)
            {
                case 668:
                    return 3;
                case 709:
                    return 4;
                case 501:
                    return 1;
                    break;
                case 508:
                    return 2;
                default:
                    return 2;
            }
        }

        public static string FindLabelGame(int index)
        {
            switch (index)
            {
                case 1:
                    return "DP";
                case 2:
                    return "PtHGSS";
                case 3:
                    return "BW";
                case 4:
                    return "BW2";
                case 5:
                    return "XY";
                default:
                    return "BW";
            }
        }
    }
}
