namespace firstAPI.model
{
    public class UserLogin
    {
        public int LoginID { get; set; } // Identity column, not nullable

        public string Username { get; set; } = null!; // NOT NULL

        public string PasswordHash { get; set; } = null!; // NOT NULL

        public string Role { get; set; } = null!; // NOT NULL

        public int? LinkedID { get; set; } // Nullable

        public string? LastLogin { get; set; } // Nullable

        public string? LastLogout { get; set; } // Nullable

        public int? LoginAttempts { get; set; } // Nullable

        public bool? IsActive { get; set; } // Nullable

        public string? CreatedAt { get; set; } // Nullable

        public string? UpdatedAt { get; set; } // Nullable

    }
}
