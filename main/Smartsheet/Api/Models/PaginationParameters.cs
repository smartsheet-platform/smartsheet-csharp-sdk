using Smartsheet.Api.Internal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Builds optional query string parameters for pagination.
    /// </summary>
    public class PaginationParameters
    {
        /// <summary>
        /// if true, include all elements in the result set
        /// </summary>
        private bool includeAll;

        /// <summary>
        /// the desired page size
        /// </summary>
        private int? pageSize;

        /// <summary>
        /// the desired page
        /// </summary>
        private int? page;

        /// <summary>
        /// Builds optional query string parameters for pagination.
        /// <remarks>Most index endpoints default to a page size of 100 results. If you need all results at once, 
        /// you should specify the includeAll=true query string parameter.</remarks>
        /// </summary>
        /// <param name="includeAll">If true, include all results (i.e. do not paginate). 
        /// Mutually exclusive with pageSize and page (they are ignored if includeAll=true is specified)</param>
        /// <param name="pageSize">The maximum number of items to return per page. Unless otherwise stated for a specific endpoint, 
        /// defaults to 100 if not specified.</param>
        /// <param name="page">Which page to return. Defaults to 1 if not specified.</param>
        public PaginationParameters(bool includeAll, int? pageSize = null, int? page = null)
        {
            this.includeAll = includeAll;
            this.pageSize = pageSize;
            this.page = page;
        }

        /// <summary>
        /// If true, include all results (i.e. do not paginate). 
        /// Mutually exclusive with pageSize and page (they are ignored if includeAll=true is specified).
        /// </summary>
        public bool IncludeAll
        {
            get { return includeAll; }
            set { includeAll = value; }
        }

        /// <summary>
        /// The maximum number of items to return per page. 
        /// Unless otherwise stated for a specific endpoint, defaults to 100 if not specified.
        /// </summary>
        public int? PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// Which page to return. Defaults to 1 if not specified.
        /// </summary>
        public int? Page
        {
            get { return page; }
            set { page = value; }
        }

        /// <summary>
        /// Returns a formatted string of query string parameters.
        /// </summary>
        /// <returns>the query string</returns>
        public string ToQueryString()
        {
            IDictionary<string, string> parameters = this.toDictionary();
            return QueryUtil.GenerateUrl(null, parameters);
        }

        /// <summary>
        /// Returns a dictionary of query string parameters.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> toDictionary()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("includeAll", includeAll.ToString().ToLower());

            if (!includeAll)
            {
                if (pageSize.HasValue)
                {
                    parameters.Add("pageSize", pageSize.ToString().ToLower());
                }
                if (page.HasValue)
                {
                    parameters.Add("page", page.ToString().ToLower());
                }
            }
            return parameters;
        }
    }
}
