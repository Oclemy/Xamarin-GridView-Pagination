using System;
using System.Collections;

namespace GridView_Pagination
{
    class Paginator
    {
    //CONSTANTS
    public const int TOTAL_NUM_ITEMS=52;
    public const int ITEMS_PER_PAGE=10;
    public const int ITEMS_REMAINING=TOTAL_NUM_ITEMS % ITEMS_PER_PAGE;
    public const int LAST_PAGE = TOTAL_NUM_ITEMS / ITEMS_PER_PAGE;

    /*
     * GENERATE A SINGLE PAGE DATA
     * PASS US THE CURRENT PAGE POSITION THEN WE GENERATE NECEASSARY DATA
     */
    public ArrayList generatePage(int currentPage)
    {
        int startItem=currentPage*ITEMS_PER_PAGE+1;
        const int numOfData = ITEMS_PER_PAGE;

        ArrayList pageData=new ArrayList();
        
        if (currentPage==LAST_PAGE && ITEMS_REMAINING>0)
        {
            for (int i=startItem;i<startItem+ITEMS_REMAINING;i++)
            {
                pageData.Add("Number "+i);
            }
        }else
        {
            for (int i=startItem;i<startItem+numOfData;i++)
            {
                pageData.Add("Number "+i);
            }
        }


        return pageData;
    }
    }
}