# Xamarin_SplashDemo

###This sample describes how to create a splash screen in android Xamarin App with support to a multiple localization.

1. Start creating a new Value Resource, called Style.xml. This Resource is our theme for the SplashActivity.
	* Resources\values\Style.xml

2. For each language that you want, add a new Drawable Resource, remember, on Xamarin the language ID have a "-r" char, like Portuguese, Brazil "drawable-pt-rBR" or English, Canada "drawable-en-rCA" 
	* List of [locales codes](https://web.archive.org/web/20120814113314/http://colincooper.net/blog/2011/02/17/android-supported-language-and-locales/)
	* In this sample we rename the image to "splash_logo" (Resources\Drawable\splash_logo.png)

3. Create a new XML file on the default drawable folder, for the splash image layer.
	```
	<?xml version="1.0" encoding="utf-8"?>
	<layer-list xmlns:android="http://schemas.android.com/apk/res/android">
  		<item>
    			<color android:color="#FFFFFF"/>
  		</item>
  		<item>
    		<bitmap
        		android:src="@drawable/splash_logo"
        		android:tileMode="disabled"
        		android:gravity="center"/>
  		</item>
	</layer-list>
	```
4. Now, create a new Activity, in this case we will call "SplashActivity". This Activity will be the "Main Activity", responsible for initialize our app.

