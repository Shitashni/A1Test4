using System.ComponentModel;

namespace HandicraftStore.Models
{
    public class EditUser:ApplicationUser
    {
        [ReadOnly(true)]
        public string Id { get; set; }
    }
}
