import { TestBed } from '@angular/core/testing';

import { LoadMaskService } from './load-mask.service';

describe('LoadMaskService', () => {
  let service: LoadMaskService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoadMaskService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
