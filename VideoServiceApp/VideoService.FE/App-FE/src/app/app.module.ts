import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UploadVideoComponent } from '../pages/upload-video/upload-video.component';
import { AppPrimaryButtonComponent } from './app-primary-button/app-primary-button.component';
import { VideoCardComponent } from './video-card/video-card.component';
import { ListVideosComponent } from '../pages/list-videos/list-videos.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadVideoComponent,
    AppPrimaryButtonComponent,
    VideoCardComponent,
    ListVideosComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
