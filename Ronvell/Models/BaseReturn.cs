namespace Ronvell.Models
{
    public static class BaseReturn
    {
        public static Response<T> ReturnState<T>(int state,T model,string ex=null)
        {
            Response<T> item = new Response<T>();
            if (state > 0)
            {
                item.Data =model;
            }
            else if(ex!=null)
            {
                // log
                item.IsSuccess = false;
                item.Message = ex;
            }
            return item;
        }
    }
}