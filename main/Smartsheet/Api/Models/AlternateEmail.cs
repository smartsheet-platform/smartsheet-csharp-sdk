using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// The AlternateEmail object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/?shell#alternateemail-object">AlternateEmail Object</seealso>
    public class AlternateEmail : IdentifiableModel
    {
        /// <summary>
        /// Flag indicating whether the alternate email address has been confirmed
        /// </summary>
        private bool? confirmed;

        /// <summary>
        /// The user's alternate email address
        /// </summary>
        private string email;

        /// <summary>
        /// The confirmed flag for AlternateEmail.
        /// </summary>
        /// <returns> the Confirmed</returns>
        public bool? Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }

        /// <summary>
        /// The email address string for AlternateEmail.
        /// </summary>
        /// <returns> the Email</returns>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// A convenience class to help generate AlternateEmail object with the appropriate fields.
        /// </summary>
        public class AlternateEmailBuilder
        {
            private string email;

            /// <summary>
            /// Sets the required properties for creating an AlternateEmail.
            /// </summary>
            /// <param name="email"> the AlternateEmail email</param>
            public AlternateEmailBuilder(string email)
            {
                this.email = email;
            }

            /// <summary>
            /// Sets the Email for the AlternateEmail.
            /// </summary>
            /// <param name="email"> the Email </param>
            /// <returns> creates the alternate email builder </returns>
            public AlternateEmailBuilder SetEmail(string email)
            {
                this.email = email;
                return this;
            }

            /// <summary>
            /// Gets the Email.
            /// </summary>
            /// <returns> the Email </returns>
            public string GetEmail()
            {
                return email;
            }

            /// <summary>
            /// Builds the AlternateEmail.
            /// </summary>
            /// <returns> the alternate email</returns>
            public AlternateEmail Build()
            {
                if (email == null)
                {
                    throw new MemberAccessException("An email address is required.");
                }

                AlternateEmail altEmail = new AlternateEmail();
                altEmail.email = email;
                return altEmail;
            }
        }
    }
}
