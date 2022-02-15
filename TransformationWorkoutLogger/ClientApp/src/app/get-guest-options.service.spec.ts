import { TestBed } from '@angular/core/testing';

import { GetGuestOptionsService } from './get-guest-options.service';

describe('GetGuestOptionsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetGuestOptionsService = TestBed.get(GetGuestOptionsService);
    expect(service).toBeTruthy();
  });
});
