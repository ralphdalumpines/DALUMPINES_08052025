import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UploadVideoComponent } from './pages/upload-video/upload-video.component';
import { AppPrimaryButtonComponent } from './app-primary-button/app-primary-button.component';
import { VideoCardComponent } from './video-card/video-card.component';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';

@NgModule({
  declarations: [        
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    UploadVideoComponent,
    AppPrimaryButtonComponent,
    VideoCardComponent,
    ListVideosComponent
  ],
  exports: [    
    UploadVideoComponent,
    AppPrimaryButtonComponent,
    VideoCardComponent,
    ListVideosComponent
  ],
  providers: [],
  bootstrap: []
})
export class AppModule { }
