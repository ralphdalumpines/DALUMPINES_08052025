import { Component, input } from '@angular/core';
import { VideoFile } from '../../models/VideoFile';
import { VideoFileService } from '../../services/clientService/video-file.service'; 
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-play-video',
  templateUrl: './play-video.component.html',
  styleUrls: ['./play-video.component.css']
})

export class PlayVideoComponent {
  path : string | null = null; 
  id : number = 0;

  constructor(private videofileService: VideoFileService,private route: ActivatedRoute) {
  
    this.route.params.subscribe(params => {
      this.id = params['id']; 

      this.videofileService.getVideoFile(this.id).subscribe({
      next: (data) => {
        let videoFile : VideoFile = data.value; // Assuming data.value is a VideoFile object
        this.path = videoFile.path; // Set the path to the video file
      },
      error: (err) => console.error('Failed to fetch video', err)
    }); 
    });  
   
  }
}
