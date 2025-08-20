import { Component, OnInit } from '@angular/core';
import { VideoFile } from '../../models/VideoFile';
import { VideoFileService } from '../../services/clientService/video-file.service';
import { VideoCardComponent } from '../../components/video-card/video-card.component';
import { Result } from '../../models/Result';

@Component({
  selector: 'app-list-videos',
  templateUrl: './list-videos.component.html',
  styleUrls: ['./list-videos.component.css'],
  imports: [VideoCardComponent]
})

export class ListVideosComponent implements OnInit {
  videos : VideoFile[] = [];

  constructor(private videoFileService: VideoFileService) {
    
    this.videoFileService.getVideoFiles().subscribe({
      next: (data) => {
        this.videos = data.value; // Assuming data.value is an array of VideoFile
      },
      error: (err) => console.error('Failed to fetch videos', err)
    });
  }

  ngOnInit() {
  }
}
