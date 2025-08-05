import { Component, input } from '@angular/core';

@Component({
  selector: 'app-primary-button',
  templateUrl: './app-primary-button.component.html',
  styleUrls: ['./app-primary-button.component.css']
})

export class AppPrimaryButtonComponent {
  label = input<string>('Button');
  type = input<string>('button');
}
