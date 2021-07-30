﻿using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Forms
{
     public partial class StatusForm : Form
     {
          User m_LoggedInUser;
          public StatusForm(User i_LoggedInUser)
          {
               m_LoggedInUser = i_LoggedInUser;
               InitializeComponent();
               fetchPosts();
          }

          private void fetchPosts()
          {
               m_ListBoxPastPost.Items.Clear();

               foreach (Post post in m_LoggedInUser.Posts)
               {
                    if (post.Message != null)
                    {
                         m_ListBoxPastPost.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                         m_ListBoxPastPost.Items.Add(post.Caption);
                    }
                    else
                    {
                         m_ListBoxPastPost.Items.Add(string.Format("[{0}]", post.Type));
                    }
               }

               if (m_ListBoxPastPost.Items.Count == 0)
               {
                    MessageBox.Show("No Posts to retrieve :(");
               }
          }

          private void m_ButtonPost_Click(object sender, EventArgs e)
          {
               try
               {
                    Status postedStatus = m_LoggedInUser.PostStatus(m_TextBoxPost.Text);
                    MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.ToString());
               }
          }

     }
}