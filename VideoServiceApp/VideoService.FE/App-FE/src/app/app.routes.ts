import { Routes } from '@angular/router';
import { UploadVideoComponent } from './pages/upload-video/upload-video.component';
import { ListVideosComponent } from './pages/list-videos/list-videos.component';
import { PlayVideoComponent } from './pages/play-video/play-video.component';

export const routes: Routes = [
    {
        path: '', component:ListVideosComponent
    },
    {    
        path: 'upload', component: UploadVideoComponent
    },
    {
        path: 'video/:id', component:PlayVideoComponent
    }  
];
