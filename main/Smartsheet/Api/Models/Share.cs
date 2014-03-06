using System;
namespace Smartsheet.Api.Models
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	/// <summary>
	/// Represents a Share Object. </summary>
	/// <seealso href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/520104-sharing-Sheets">Sharing Sheets</seealso>
	public class Share : NamedModel
	{
		/// <summary>
		/// Represents the access level for this specific share.
		/// </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// Represents the Email for this specific share.
		/// </summary>
		private string email;

		/// <summary>
		/// Gets the access level for this specific share.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}


		/// <summary>
		/// Gets the Email for this specific share.
		/// </summary>
		/// <returns> the Email </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields for sharing the sheet To one user.
		/// </summary>
		public class ShareToOneBuilder
		{
			internal AccessLevel? accessLevel;
			internal string email;

			/// <summary>
			/// Access level for this specific share.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel = accessLevel;
				return this;
			}

			/// <summary>
			/// Email address for this specific share.
			/// </summary>
			/// <param name="email"> the Email </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetEmail(string email)
			{
				this.email = email;
				return this;
			}

			/// <summary>
			/// Gets the access level.
			/// </summary>
			/// <returns> the access level </returns>
			public virtual AccessLevel? AccessLevel
			{
				get
				{
					return accessLevel;
				}
			}

			/// <summary>
			/// Gets the Email.
			/// </summary>
			/// <returns> the Email </returns>
			public virtual string Email
			{
				get
				{
					return email;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="Share"/> object.
			/// </summary>
			/// <returns> the share </returns>
			public virtual Share Build()
			{
				if (email == null || accessLevel == null)
				{
					throw new InvalidOperationException("The email and accessLevel are required.");
				}

				Share share = new Share();
				share.accessLevel = accessLevel;
				share.email = email;

				return share;
			}
		}

		/// <summary>
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields To update a specific share.
		/// </summary>
		public class UpdateShareBuilder
		{
			internal AccessLevel? accessLevel;

			/// <summary>
			/// Access level for the share.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the update share builder </returns>
			public virtual UpdateShareBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel = accessLevel;
				return this;
			}

			/// <summary>
			/// Gets the access level.
			/// </summary>
			/// <returns> the access level </returns>
			public virtual AccessLevel? AccessLevel
			{
				get
				{
					return accessLevel;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="Share"/> object.
			/// </summary>
			/// <returns> the share </returns>
			public virtual Share Build()
			{
				if (accessLevel == null)
				{
					throw new InvalidOperationException("The access level must be specified.");
				}

				Share share = new Share();
				share.accessLevel = accessLevel;
				return share;
			}
		}
	}

}