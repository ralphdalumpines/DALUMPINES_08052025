import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./pages/list-videos/list-videos.component').then(m => m.ListVideosComponent)
    },
    {    
        path: 'upload',
        loadChildren: () => import('./pages/upload-video/upload-video.component').then(m => m.UploadVideoComponent)
    },
    {
        path: 'video/:id',
        loadChildren: () => import('./pages/play-video/play-video.component').then(m => m.PlayVideoComponent)
    }
];
