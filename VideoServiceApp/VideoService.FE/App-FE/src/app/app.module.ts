import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UploadVideoComponent } from './pages/upload-video/upload-video.component';
import { AppPrimaryButtonComponent } from './components/primary-button/app-primary-button.component';
import { VideoCardComponent } from './components/video-card/video-card.component';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';
import { PlayVideoComponent } from './pages/play-video/play-video.component';
import { TooltipComponent } from './components/tooltip/tooltip.component';

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
    ListVideosComponent,
    PlayVideoComponent,
    TooltipComponent
  ],
  exports: [    
    UploadVideoComponent,
    AppPrimaryButtonComponent,
    VideoCardComponent,
    ListVideosComponent,
    PlayVideoComponent,
    TooltipComponent
  ],
  providers: [],
  bootstrap: []
})
export class AppModule { }
