import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent implements OnInit {
  @Input() member: Member;
  uploader: FileUploader;
  hasBaseDropZoneOver: false;
  baseUrl = environment.apiUrl;
  user: User;

  constructor(private accountService: AccountService) {
    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((user) => (this.user = user));
  }

  ngOnInit(): void {
    this.initializeUploader();
  }
  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }
  initializeUploader() {
    console.log('Gate 1');
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });
    console.log('Gate 2');

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
      console.log('Gate 3');
    };
    console.log('Gate 4');

    this.uploader.onSuccessItem = (item, res, stat, headers) => {
      console.log('Gate 3');

      if (res) {
        const photo = JSON.parse(res);
        this.member.photos.push(photo);
      }
    };
    console.log('Gate 5');
  }
}
