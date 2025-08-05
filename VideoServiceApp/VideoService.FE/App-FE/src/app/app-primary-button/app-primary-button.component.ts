import { Component, input } from '@angular/core';

@Component({
  selector: 'app-primary-button',
  templateUrl: './app-primary-button.component.html',
  styleUrls: ['./app-primary-button.component.css'],
  standalone: true
})

export class AppPrimaryButtonComponent {
  label = input<string>('');
  type = input<string>('button');
}
