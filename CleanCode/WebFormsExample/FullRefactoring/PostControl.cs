using System;
using System.Reflection.Emit;

namespace CleanCode.WebFormsExample.FullRefactoring
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostRepository _postRepository;
        private readonly PostValidator _validator;
        private Label PostBody { get; set; }
        private Label PostTitle { get; set; }
        private int? PostId { get; set; }

        public PostControl()
        {
            _postRepository = new PostRepository();
            _validator = new PostValidator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                TrySavePost();
            else
                DisplayPost();
        }

        private void TrySavePost()
        {
            var post = new GetPost();
            var results = validator.Validate(post);

            if (results.IsValid)
                _postRepository.SavePost(post);
            else
                DisplayErrors(results);
        }

        private void DisplayErrors(ValidationResult results)
        {
            var summary = GetErrorSummaryControl();

            foreach (var error in results.Errors)
            {
                var label = GetErrorLabel(error);

                if (label == null)
                    summary.Items.Add(new ListItem(error.ErrorMessage));
                else
                    label.Text = error.ErrorMessage;
            }
        }

        private static BulletedList GetErrorSummaryControl()
        {
            return (BulletedList)FindControl("ErrorSummary");
        }

        private static Label GetErrorLabel(object error)
        {
            return FindControl(error.PropertyName + "Error") as Label;
        }

        private void DisplayPost()
        {
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            var post = _postRepository.GetPost(postId);
            PostBody.Text = post.Body;
            PostTitle.Text = post.Title;
        }

        private Post GetPost()
        {
            return new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }
    }
}