﻿using Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class Mailtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MailHelper mh = new MailHelper();
            mh.SendMailMessage("dlsudmailer@gmail.com", ConfigurationManager.AppSettings.Get("testemail"), "What's up buddy?", 
                @"Essays are generally scholarly pieces of writing giving the author's own argument, but the definition is vague, overlapping with those of an article, a pamphlet and a short story.

Essays can consist of a number of elements, including: literary criticism, political manifestos, learned arguments, observations of daily life, recollections, and reflections of the author. Almost all modern essays are written in prose, but works in verse have been dubbed essays (e.g. Alexander Pope's An Essay on Criticism and An Essay on Man). While brevity usually defines an essay, voluminous works like John Locke's An Essay Concerning Human Understanding and Thomas Malthus's An Essay on the Principle of Population are counterexamples. In some countries (e.g., the United States and Canada), essays have become a major part of formal education. Secondary students are taught structured essay formats to improve their writing skills, and admission essays are often used by universities in selecting applicants and, in the humanities and social sciences, as a way of assessing the performance of students during final exams.

The concept of an essay has been extended to other mediums beyond writing. A film essay is a movie that often incorporates documentary film making styles and which focuses more on the evolution of a theme or an idea. A photographic essay is an attempt to cover a topic with a linked series of photographs; it may or may not have an accompanying text or captions.");
        }
    }
}