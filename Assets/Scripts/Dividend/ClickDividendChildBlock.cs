using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickDividendChildBlock : MonoBehaviour
{

    public static ClickDividendChildBlock Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<string> Prefab_1 = new List<string>
    {
        "4 Corner","King Corners","Queen Corners","4 Corner and Center","Bulls Eyes","Twin Lines","6 Corners","6 Corners and Center","Reverse Twin","Early 5/Jaldi 5","Early 6/Jaldi 6",
        "Early 7/Jaldi 7","Early 8/Jaldi 8","Early 9/Jaldi 9","Early 10/Jaldi 10","Early 11/Jaldi 11","Early 12/Jaldi 12","Early 13/Jaldi 13","Early 14/Jaldi 14","Breakfast","Lunch","Dinner",
        "Day || Jawani","Night || Budhapa","Center Laddu","Bamboo","Safe","Fence","First Half","Sencond Half", "Shehnai Bidaai","Brahma","Vishnu","Mahesh","Railway Truck","Drum","ZIP","ZAP",
        "Letter C","Letter I","Letter D","CID","Letter H","Letter T","Letter L","Digit 7","Pyramid","Reverse Pyramid","Circle","All Even","All Odd","Eclipse","Plus","Temp / BP","Double Temp",
        "Triple Temp","5 Min 5 Max","5 Minimum","5 Max Number", "Anda","Danda","Anda Danda","5 Pandav","Hockey Stick","Fat Lady","Ugly Duckling","Naughty 6 & 9","26 January",
        "1 Pair (Row)","2 Pair (Row)","3 Pair (Row)","4 Pair (Row)","All Pair (Row)","1 Pair (Column)","2 Pair (Column)","3 Pair (Column)","4 Pair (Column)","All Pair (Column)",
        "First / Top Line","Second / Middle Line","Third Line / Last Line", "I Love You 143","We Love You 243","Love You Too 433","You And Me 332","124","421","225","Work From Home 444",
        "Stay At Home 424","123","333","Jai Shree Ram 353","4 2 ka 1(Reverse)","333(reverse)","3 2 ka 1 (Reverse)","Wear Mask","House"
    };


    [HideInInspector]
    public Dictionary<string, string> DividendFeatures = new Dictionary<string, string>
    {

        {"Block 1 / Breakfast 1", "Ticket #1: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 2 / Lunch 1", "Ticket #1: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 3 / Dinner 1", "Ticket #1: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Block 4 / Breakfast 2", "Ticket #2: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 5 / Lunch 2", "Ticket #2: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 6 / Dinner 2", "Ticket #2: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Block 7 / Breakfast 3", "Ticket #3: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 8 / Lunch 3", "Ticket #3: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 9 / Dinner 3", "Ticket #3: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Block 10 / Breakfast 4", "Ticket #4: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 11 / Lunch 4", "Ticket #4: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 12 / Dinner 4", "Ticket #4: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Block 13 / Breakfast 5", "Ticket #5: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 14 / Lunch 5", "Ticket #5: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 15 / Dinner 5", "Ticket #5: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Block 16 / Breakfast 6", "Ticket #6: All the numbers of 1st, 2nd and 3rd vertical lines (Columns) are marked" },
        {"Block 17 / Lunch 6", "Ticket #6: All the numbers of 4th, 5th and 6th vertical lines (Columns) are marked" },
        {"Block 18 / Dinner 6", "Ticket #6: All the numbers of 7th, 8th and 9th vertical lines (Columns) are marked" },
        {"Line1" , "1st Line: All numbers are marked" },
        {"Line2" , "2nd Line: All numbers are marked" },
        {"Line3" , "3rd Line: All numbers are marked" },
        {"Line4" , "4th Line: All numbers are marked" },
        {"Line5" , "5th Line: All numbers are marked" },
        {"Line6" , "6th Line: All numbers are marked" },
        {"Line7" , "7th Line: All numbers are marked" },
        {"Line8" , "8th Line: All numbers are marked" },
        {"Line9" , "9th Line: All numbers are marked" },
        {"Line10" , "10th Line: All numbers are marked" },
        {"Line11" , "11th Line: All numbers are marked" },
        {"Line12" , "12th Line: All numbers are marked" },
        {"Line13" , "13th Line: All numbers are marked" },
        {"Line14" , "14th Line: All numbers are marked" },
        {"Line15" , "15th Line: All numbers are marked" },
        {"Line16" , "16th Line: All numbers are marked" },
        {"Line17" , "17th Line: All numbers are marked" },
        {"Line18" , "18th Line: All numbers are marked" },
        {"Ticket #1:Early 5" , "Ticket #1:When ant 5 numbers are marked" },
        {"Ticket #2:Early 5" , "Ticket #2:When ant 5 numbers are marked" },
        {"Ticket #3:Early 5" , "Ticket #3:When ant 5 numbers are marked" },
        {"Ticket #4:Early 5" , "Ticket #4:When ant 5 numbers are marked" },
        {"Ticket #5:Early 5" , "Ticket #5:When ant 5 numbers are marked" },
        {"Ticket #6:Early 5" , "Ticket #6:When ant 5 numbers are marked" },
        {"All 6 Top Lines" , "When all numbers of Top line of all 6 tickets of the sheet are marked" },
        {"All 6 Middle Lines" , "When all numbers of Middle line of all 6 tickets of the sheet are marked" },
        {"All 6 Last Lines" , "When all numbers of last line of all 6 tickets of the sheet are marked" },
        {"Outer Lines(#1 & #18)" , "When all numbers of 1st and 18th lines are marked" },
        {"Inner Lines(#9 & #10)" , "When all numbers of 9th and 10th lines are marked" },
        {"4 Corner" , "First and Last numbers of top and bottom rows" },
        {"King Corners" , "When last numbers of each rows is marked" },
        {"Queen Corners" , "When first numbers of each rows is marked" },
        {"4 Corner and Center" , "" },
        {"Bulls Eyes" , "2nd and 4th numbers of each line are marked" },
        {"Twin Lines" , "1st and 2nd numbers of each line are marked" },
        {"6 Corners", "First and last number of each row is marked" },
        {"6 Corners and Center", "First and last number of each row is marked and 3rd number middle row is marked" },
        {"Reverse Twin", "if 4th and 5th number of each line are marked" },
        {"Early 5/Jaldi 5", "When any 5 numbers are marked" },
        {"Early 6/Jaldi 6", "When any 6 numbers are marked" },
        {"Early 7/Jaldi 7", "When any 7 numbers are marked" },
        {"Early 8/Jaldi 8", "When any 8 numbers are marked" },
        {"Early 9/Jaldi 9", "When any 9 numbers are marked" },
        {"Early 10/Jaldi 10", "When any 10 numbers are marked" },
        {"Early 11/Jaldi 11", "When any 11 numbers are marked" },
        {"Early 12/Jaldi 12", "When any 12 numbers are marked" },
        {"Early 13/Jaldi 13", "When any 13 numbers are marked" },
        {"Early 14/Jaldi 14", "When any 14 numbers are marked" },
        {"Breakfast", "All the numbers of 1st,2nd and 3rd vertical lines(Columns) are marked" },
        {"Lunch", "All the numbers of 4th,5th and 6th vertical lines(Columns) are marked" },
        {"Dinner", "All the numbers of 7th,8th and 9th vertical lines(Columns) are marked" },
        {"Day || Jawani", "When all the numbers from 1 to 45 are marked" },
        {"Night || Budhapa", "When all the numbers from 46 to 90 are marked" },
        {"Center Laddu", "When 3rd number of Second line(row) is marked" },
        {"Bamboo", "\"When 3rd number of each line(row) is marked" },
        {"Safe", "All numbers marked which are not on ticket border" },
        {"Fence", "When all numbers on boundaries are marked" },
        {"First Half", "When 1st,2nd and 3rd numbers of each line (row) are marked" },
        {"Sencond Half", "When 3rd,4th and 5th numbers of each line (row) are marked" },
        {"Shehnai Bidaai", "if first 3 numbers of Top row and last 3 numbers of last row are marked" },
        {"Brahma", "When all numbers from 1 to 30 are marked" },
        {"Vishnu", "When all numbers from 31 to 60 are marked" },
        {"Mahesh", "When all numbers from 61 to 90 are marked" },
        {"Drum", "if 2nd,3rd and 4th numbers of all rows are marked" },
        {"ZIP", "if 1st and 2nd numbers of Top line + 3rd number of middle line + 4th and 5th numbers of last line are marked" },
        {"ZAP", "if 4th,5th and 2nd numbers of Top line + 3rd number of middle line + 1st and 2nd numbers of last line are marked" },
        {"Letter C", "When all the numbers in letter C pattern are marked" },
        {"Letter I", "When all the numbers in letter I pattern are marked" },
        {"Letter D", "When all the numbers in letter D pattern are marked" },
        {"CID", "For C,1st 3 box of 1st line,1st box of 2nd line and 1st 3 box of 3rd line.....For I,5th Column.....For D,last 3 box of 1st line,7th and 9th box of 2nd line and last 3 box of 3rd line" },
        {"Letter H", "" },
        {"Letter T", "" },
        {"Letter L", "When all the numbers in letter L pattern are marked" },
        {"Digit 7", "When all thr number in digit 7 pattern are marked. Means all the numbers of Top row and Last column should be marked" },
        {"Pyramid", "if 3rd number of top row,2nd and 4th numbers of middle row and 1st,3rd and 5th number of last row are marked" },
        {"Reverse Pyramid", "if 1st,3rd and 5th number of top row,2nd and 4th numbers of middle row and 3rd number of last row are marked" },
        {"Circle", "if 3rd number of top row,2nd and 4th numbers of middle row and 1st,3rd  number of last row are marked" },
        {"All Even", "if all even numbers of ticket are marked" },
        {"All Odd", "if all odd numbers of ticket are marked" },
        {"Eclipse", "if 3rd number of all 3 rows and 2nd and 4th numbers of middle row are marked" },
        {"Plus","if 3rd number of all 3 rows and 2nd and 4th numbers of middle row are marked" },
        {"Temp / BP", "if smallest and highest number of ticket are marked" },
        {"Double Temp", "if 2 smallest and 2 highest numbers of ticket are marked" },
        {"Triple Temp", "if 3 smallest and 3 highest numbers of ticket are marked" },
        {"5 Min 5 Max", "if 5 smallest and 5 highest numbers of ticket are marked" },
        {"5 Minimum", "if 5 minimum numbers of ticket are marked" },
        {"5 Max Number", "if 5 maximum numbers of ticket are marked" },
        { "Anda", "if all numbers of ticket containing 0 are marked" },
        { "Danda", "if all numbers of ticket containing 1 are marked" },
        { "Anda Danda", "if all numbers of ticket containing 0 and 1 are marked" },
        { "5 Pandav", "if all numbers of ticket containing 5 are marked" },
        { "Hockey Stick", "if all numbers of ticket containing 7 are marked" },
        { "Fat Lady", "if all numbers of ticket containing 8 are marked" },
        { "Ugly Duckling", "if all numbers of ticket containing 2 are marked" },
        { "Naughty 6 & 9", "if all numbers of ticket containing 6 and 9 are marked" },
        { "26 January", "if all numbers of ticket containing 2 and 6 are marked" },
        { "1 Pair (Row)", "If in any row, 1 pair of 2 numbers together are marked" },
        { "2 Pair (Row)", "If in any row, 2 pair of 2 numbers together are marked" },
        { "3 Pair (Row)", "If in any row, 3 pair of 2 numbers together are marked" },
        { "4 Pair (Row)", "If in any row, 4 pair of 2 numbers together are marked" },
        { "All Pair (Row)", "If in any row, all pair of 2 numbers together are marked" },
        { "1 Pair (Column)", "If in any column,1 Pair of 2 numbers vertically together are marked" },
        { "2 Pair (Column)", "If in any column,2 Pair of 2 numbers vertically together are marked" },
        { "3 Pair (Column)", "If in any column,3 Pair of 2 numbers vertically together are marked" },
        { "4 Pair (Column)", "If in any column,4 Pair of 2 numbers vertically together are marked" },
        { "All Pair (Column)", "If in any column,All Pair of 2 numbers vertically together are marked" },
        { "First / Top Line", "All the numbers of first/top row of a ticket" },
        { "Second / Middle Line", "All the numbers of second/middle row of a ticket" },
        { "Third Line / Last Line", "All the numbers of third/last row of a ticket" },
        { "Super 12", "When and 2 number of all rows of all 6 tickets are marked" },
        { "Super 18", "When and 3 number of all rows of all 6 tickets are marked" },
        { "Super 24", "When and 4 number of all rows of all 6 tickets are marked" },
        { "Super 30", "When and 5 number of all rows of all 6 tickets are marked" },
        { "Super 36", "When and 6 number of all rows of all 6 tickets are marked" },
        { "Super 42", "When and 7 number of all rows of all 6 tickets are marked" },
        { "Sheet Queen Corners", "When 1st number of all rows of all 6 tickets are marked" },
        { "Sheet King Corners", "When 5th number of all rows of all 6 tickets are marked" },
        { "Sheet Corners", "When 1st and 5th number of Top and Bottom rows of all 6 tickets are marked" },
        { "Beginners 6", "When 1st number of the Top line of all 6 tickets are marked" },
        { "Finishers 6", "When 5th number of the Bottom line of all 6 tickets are marked" },
        { "Sheet Bull Eyes", "When 3rd number of the Middle line of all 6 tickets are marked" },
        { "8 Corners", "1st & 5th number of the Top Line of Ticket #1 + 1st & 5th number of the Bottom Line of Ticket #3 + 1st & 5th number of the Top Line of Ticket #4 + 1st & 5th number of the Bottom Line of Ticket #6 " },
        { "4 Corners", "1st & 5th number of the Top Line of Ticket #1 + 1st & 5th number of the Bottom Line of Ticket #6" },
        { "I Love You 143", "if 1st number of top row,1st,2nd,3rd and 4th numbers of middle row and 1st,2nd and 3rd number of last row are marked" },
        { "We Love You 243", "if 1st and 2nd number of top row,1st,2nd,3rd and 4th numbers of middle row and 1st,2nd and 3rd number of last row are marked" },
        { "Love You Too 433", "if 1st,2nd,3rd and 4th number of top row,1st,2nd and 3rd numbers of middle row and 1st,2nd and 3rd number of last row are marked" },
        { "You And Me 332", "if 1st,2nd and 3rd number of top row,1st,2nd and 3rd numbers of middle row and 1st and 2nd number of last row are marked" },
        { "124", "if 1st number of top row,1st and 2nd numbers of middle row and 1st,2nd,3rd and 4th number of last row are marked" },
        { "421", "if 1st,2nd,3rd and 4th number of top row,1st and 2nd numbers of middle row and 1st number of last row are marked" },
        { "225", "if 1st and 2nd number of top row,1st and 2nd numbers of middle row and 1st,2nd,3rd,4th and 5th number of last row are marked" },
        { "Work From Home 444", "if 1st,2nd,3rd and 4th number of all lines are marked" },
        { "Stay At Home 424", "if 1st,2nd,3rd and 4th number of top row,1st and 2nd numbers of middle row and 1st,2nd,3rd and 4th number of last row are marked" },
        { "123", "if 1st number of top row,1st and 2nd numbers of middle row and 1st,2nd and 3rd number of last row are marked" },
        { "333", "if 1st,2nd and 3rd number of all lines are marked" },
        { "Jai Shree Ram 353", "if 1st,2nd and 3rd number of top row,1st,2nd, 3rd ,4th and 5th numbers of middle row and 1st ,2nd and 3rd number of last row are marked" },
        { "4 2 ka 1(Reverse)", "if 2nd,3rd,4th and 5th number of top row,5th and 4th numbers of middle row and 5th number of last row are marked" },
        {"333(reverse)","if 3rd,4th and 5th number of all lines are marked" },
        { "3 2 ka 1 (Reverse)", "if 3rd,4th and 5th number of top rows ,4th and 5th numbers of middle row and 5th number of last row are marked" },
        { "Wear Mask", "if 2nd,3rd and 4th number of middle row and 4 corners i.e. 1st and last number of Top and Bottom Rows are marked" },
        { "Ticket #1 House", "Ticket #1: When all numbers of the ticket are marked" },
        { "Ticket #2 House", "Ticket #2: When all numbers of the ticket are marked" },
        { "Ticket #3 House", "Ticket #3: When all numbers of the ticket are marked" },
        { "Ticket #4 House", "Ticket #4: When all numbers of the ticket are marked" },
        { "Ticket #5 House", "Ticket #5: When all numbers of the ticket are marked" },
        { "Ticket #6 House", "Ticket #6: When all numbers of the ticket are marked" },
        { "Odd Houses(#1,#3,#5)", "" },
        { "Even Houses(#2,#4,#6)", "" },
        { "Top 3 Houses", "Ticket #1,#2,#3 All numbers are marked" },
        { "Bottom 3 Houses", "Ticket #4,#5,#6 All numbers are marked" },
        { "Outer Houses(#1 & #6)", "Ticket #1,#6 : All numbers are marked" },
        { "Inner Houses(#3 & #4)", "Ticket #3,#4 : All numbers are marked" },
        { "Top 2 Houses(#1 & #2)", "Ticket #1,#2 : All numbers are marked" },
        { "Bottom 2 Houses(#5 & #6)", "Ticket #5,#6 : All numbers are marked" },
        { "House", "All the numbers of a ticket" },

    };

    public void openPanelfromGenerateDividendTicket()
    {
        GenerateDividendTicket.instance.TicketInBlockPanel.SetActive(true);
        if(Prefab_1.Contains(gameObject.name))
        {
            GenerateDividendTicket.instance.Ticket_1_Prefab.SetActive(true);
            GenerateDividendTicket.instance.Ticket_6_Prefab.SetActive(false);
        }
        else
        {
            GenerateDividendTicket.instance.Ticket_1_Prefab.SetActive(false);
            GenerateDividendTicket.instance.Ticket_6_Prefab.SetActive(true);
        }
        GenerateDividendTicket.instance.DividendName.text = gameObject.name;
        GenerateDividendTicket.instance.DividendFeature.text = DividendFeatures[gameObject.name];
        GenerateDividendTicket.instance.MarkRedColor();
    }





}

