using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Shop.BLL
{
    using Shop.BLL.ViewModels;
    using Shop.DAL.Repositories;

    public class CategoryBLL
    {
        CategoryRepository _db;

        public CategoryBLL()
        {
            _db = new CategoryRepository();
        }


        /**
         * 
         */
        public List<CategoryVM> getList()
        {
            var result = new List<CategoryVM>();

            // GET Data from DB
            var data = this._db.GetList();
            if ( data.Count > 0 )
            {
                // Get parents
                var parents = data.FindAll(x => x.ParentId == 0);            

                foreach (var parent in parents)
                {
                    var item = new CategoryVM()
                    {
                        Id = parent.Id,
                        Title = parent.Title,
                        ParentId = parent.ParentId,
                        StatusId = parent.StatusId,
                        Children = new List<CategoryVM>()
                    };

                    // 2nd level
                    // Find Children
                    var childrenVM = new List<CategoryVM>();
                    var childrenData = data.FindAll(x => x.ParentId == parent.Id);                    

                    if (childrenData.Count > 0 )
                    {
                        foreach (var child in childrenData)
                        {
                            var childVM = new CategoryVM();


                            childVM.Id = child.Id;
                            childVM.Title = child.Title;
                            childVM.ParentId = child.ParentId;
                            childVM.StatusId = child.StatusId;


                            // 3th level
                            var thirthChildrenVM = new List<CategoryVM>();

                            var thirthChildrenData = data.FindAll(x => x.ParentId == child.Id);

                            if (thirthChildrenData.Count > 0)
                            {
                                foreach (var thirthChild in thirthChildrenData)
                                {
                                    var thirthChildVM = new CategoryVM();
                                    thirthChildVM.Id = thirthChild.Id;
                                    thirthChildVM.Title = thirthChild.Title;
                                    thirthChildVM.ParentId = thirthChild.ParentId;
                                    thirthChildVM.StatusId = thirthChild.StatusId;
                                    //thirthChildVM.Children = new List<CategoryVM>();
                                    //thirthChildVM.Children.Add(thirthChildVM);         

                                    thirthChildrenVM.Add(thirthChildVM);
                                }
                               

                                childVM.Children = thirthChildrenVM;
                            }                            

                            item.Children.Add(childVM);
                        }
                    }

                    
                    result.Add( item );
                }
            }

            return result;
        }

    }
}