

using Smartsheet.Api.Internal.Http;
using Smartsheet.Api.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
namespace Smartsheet.Api.Internal
{
	public class DiscussionCommentResourcesImpl : AbstractResources, DiscussionCommentResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public DiscussionCommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Adds a Comment to a Discussion.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions/{discussionId}/comments</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussionId"> the id of the discussion </param>
		/// <param name="comment"> Comment object </param>
		/// <returns> the created comment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment AddComment(long sheetId, long discussionId, Comment comment)
		{
			return this.CreateResource("sheets/" + sheetId + "/discussions/" + discussionId + "/comments", typeof(Comment), comment);
		}

		/// <summary>
		/// <para>Adds a Comment attached with an Attachment to a Discussion.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions/{discussionId}/comments</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussionId"> the id of the discussion </param>
		/// <param name="comment"> Comment object </param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <returns> the created comment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment AddCommentWithAttachment(long sheetId, long discussionId, Comment comment, string file, string fileType)
		{
			return this.CreateResourceWithAttachment("sheets/" + sheetId + "/discussions/" + discussionId + "/comments", comment, file, fileType);
		}
	}
}
