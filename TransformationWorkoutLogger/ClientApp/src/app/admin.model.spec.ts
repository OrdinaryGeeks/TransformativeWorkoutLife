import { Admin } from './admin.model';

describe('Admin', () => {
  it('should create an instance', () => {
    expect(new Admin('', '', false, false, '', '', '', '',false, false, false, false, false, false, '', 0, 0, '', new Date())).toBeTruthy();
  });
});
