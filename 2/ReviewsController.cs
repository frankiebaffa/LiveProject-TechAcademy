public ActionResult ReviewIndex()
{
    string UserId = HttpContext.User.Identity.GetUserId();
    var campaignReviews = db.Reviews.Where(x => x.UserId.ToString() == UserId);

    return View("Index", campaignReviews);
}
