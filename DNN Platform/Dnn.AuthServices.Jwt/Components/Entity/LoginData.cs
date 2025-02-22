﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace Dnn.AuthServices.Jwt.Components.Entity
{
    using Newtonsoft.Json;

    /// <summary>Structure used for the Login to obtain a Json Web Token (JWT).</summary>
    [JsonObject]
    public struct LoginData
    {
        /// <summary>The authentication username.</summary>
        [JsonProperty("u")]
        public string Username;

        /// <summary>The authentication password.</summary>
        [JsonProperty("p")]
        public string Password;
    }
}
