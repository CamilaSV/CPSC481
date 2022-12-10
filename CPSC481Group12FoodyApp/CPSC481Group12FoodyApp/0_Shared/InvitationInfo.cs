namespace CPSC481Group12FoodyApp.Logic
{
    public class InvitationInfo
    {
        public int inviteGroupId { get; set; }
        public string inviteSenderEmail { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            InvitationInfo other = obj as InvitationInfo;

            return (inviteGroupId == other.inviteGroupId) &&
                (inviteSenderEmail == other.inviteSenderEmail);
        }
    }
}
