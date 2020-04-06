using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sol_Demo.Behaviors
{
    public static class DisplayAlertBoxOnDataBehavior
    {
        public static readonly BindableProperty UserModelAttachBehaviorProperty =
        BindableProperty.CreateAttached(
            "UserModelAttachBehavior",
            typeof(Object),
            typeof(DisplayAlertBoxOnDataBehavior),
            false,
            propertyChanged: null);

        public static Object GetUserModelAttachBehavior(BindableObject view)
        {
            return view.GetValue(UserModelAttachBehaviorProperty);
        }

        public static void SetUserModelAttachBehavior(BindableObject view, Object value)
        {
            view.SetValue(UserModelAttachBehaviorProperty, value);
        }



        public static readonly BindableProperty ContentPageAttachBehaviorProperty =
        BindableProperty.CreateAttached(
            "ContentPageAttachBehavior",
            typeof(Object),
            typeof(DisplayAlertBoxOnDataBehavior),
            false,
            propertyChanged: null);

        public static Object GetContentPageAttachBehavior(BindableObject view)
        {
            return view.GetValue(ContentPageAttachBehaviorProperty);
        }

        public static void SetContentPageAttachBehavior(BindableObject view, Object value)
        {
            view.SetValue(ContentPageAttachBehaviorProperty, value);
        }


        public static readonly BindableProperty IsDisplayAlertAttachBehaviorProperty =
       BindableProperty.CreateAttached(
           "IsDisplayAlertAttachBehavior",
           typeof(bool),
           typeof(DisplayAlertBoxOnDataBehavior),
           false,
           propertyChanged: OnAttachBehaviorChanged);

        public static bool GetIsDisplayAlertAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(IsDisplayAlertAttachBehaviorProperty);
        }

        public static void SetIsDisplayAlertAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(IsDisplayAlertAttachBehaviorProperty, value);
        }

        private static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
           
                Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        if (view is Button)
                        {
                            Button buttonObj = view as Button;

                            var flag = (Boolean)newValue;
                            if (flag == true)
                            {
                                //// get User Model Object
                                var userModel = GetUserModelAttachBehavior(view) as UserModel;

                                //// get Content Page Object
                                var contentPage = GetContentPageAttachBehavior(view) as ContentPage;

                                if (contentPage != null && userModel != null)
                                {

                                    await contentPage.DisplayAlert("Full Name", $"{userModel.FirstName} {userModel.LastName}", "Cancel");


                                }
                            }
                        }
                    }
                    catch
                    {
                        await Application.Current.MainPage.DisplayAlert("Error","Someting went Wrong","Cancel");
                    }
                    finally
                    {
                        // De-Register Attached Property
                        SetIsDisplayAlertAttachBehavior(view, false);
                    }
                   
                });
            
                

          

            
        }

    }
}
