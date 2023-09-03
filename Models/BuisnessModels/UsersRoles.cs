namespace TaskApiV1.Models.BuisnessModels
{
    public class UsersRoles
    {
        public List<string> GetRoles()
        {
            return new List<string>() {
                "Admin",
                "Manager",
                "Team Leader",
                "Associate"
            };
        }

        public int GetRoleId(string RoleName)
        {
            return RoleName switch
            {
                "Admin" => 1,
                "Manager" => 2,
                "Team Leader" => 3,
                "Associate" => 4,
                _ => 0
            };
        }

        public string GetRoleName(int RoleId)
        {
            return RoleId switch
            {
                1 => "Admin",
                2 => "Manager",
                3 => "Team Leader",
                4 => "Associate",
                _ => "No Roles Assigned"
            };
        }
    }
}
