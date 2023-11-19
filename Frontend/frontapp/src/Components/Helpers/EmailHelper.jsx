import emailjs from '@emailjs/browser';

export const SendEmail = (data) => {
    emailjs.send('service_hzpb31k', 'template_3szy0m6', {
        'sendername': 'MyPlantCare',
        'subject': data.subject,
        'message': data.message,
        'to': data.email
    }, 'Ti_V4VCd8trgJkDsh')
      .then((result) => {
          console.log(result.text);
      }, (error) => {
          console.log(error.text);
      });
};