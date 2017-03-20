using Android.App;
using Android.Widget;
using Android.OS;

namespace GridView_Pagination
{
    [Activity(Label = "GridView_Pagination", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
		private GridView gv;
        private Button nextBtn,prevBtn;
        private readonly Paginator p = new Paginator();
        private const int totalPages = Paginator.TOTAL_NUM_ITEMS/Paginator.ITEMS_PER_PAGE;
        private int currentPage=0;

		
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            this.initializeViews();

            //BIND FIRST PAGE
            gv.Adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,p.generatePage(currentPage));
        }

        /*
         * 1. INITIALIZE VIEWS : GridView,Buttons
         * 2. HANDLE ITEMCLICKS
         */
        private void initializeViews()
        {
            //REFERENCE VIEWS
            gv = FindViewById<GridView>(Resource.Id.gv);
            nextBtn = FindViewById<Button>(Resource.Id.nextBtn);
            prevBtn = FindViewById<Button>(Resource.Id.prevBtn);
            
            prevBtn.Enabled=false;

            //BUTTON CLICKS
            nextBtn.Click += nextBtn_Click;
            prevBtn.Click += prevBtn_Click;
        }

        /*
         * PREVIOUS BUTTON CLICKED
         */
        void prevBtn_Click(object sender, System.EventArgs e)
        {            
             currentPage-=1;
             gv.Adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,p.generatePage(currentPage));
             toggleButtons();
			 
        }


        /*
         * NEXT BUTTON CLICKED
         */
        void nextBtn_Click(object sender, System.EventArgs e)
        {
            
			 currentPage+=1;
            gv.Adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,p.generatePage(currentPage));
            toggleButtons();
        }


        /*
         * TOGGLE BUTTON STATES
         */
        private void toggleButtons()
        {
            if (currentPage == totalPages)
            {
                nextBtn.Enabled=false;
                prevBtn.Enabled=true;
            }
            else
                if (currentPage == 0)
                {
                    prevBtn.Enabled=false;
                    nextBtn.Enabled=true;
                }
                else
                    if (currentPage >= 1 && currentPage <= 5)
                    {
                        nextBtn.Enabled=true;
                        prevBtn.Enabled=true;
                    }

        }
    }
}

