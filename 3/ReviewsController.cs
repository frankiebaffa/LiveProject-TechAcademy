public ActionResult Create()
{
    string UserId = HttpContext.User.Identity.GetUserId();

    //  Create raw html for each item in
    //  db.Campaigns
    string Campaign = "";
    foreach (var item in db.Campaigns)
    {
        Campaign += string.Format(
            "<li id=\"{0}\"><a><img src=\"{1}\" class=\"imgDisplay\" />" +
            "<p class=\"imageText\" id=\"dropdownName\">{2}</p></a>" +
            "</li>",
            item.CampaignID, item.ImageUrL, item.Name);
    }

    ViewBag.UserId = new SelectList(new[] { UserId });
    ViewBag.Campaign = Campaign;
    Review review = new Review();
    review.ReviewDate = DateTime.Today;

    return View(review);
}
