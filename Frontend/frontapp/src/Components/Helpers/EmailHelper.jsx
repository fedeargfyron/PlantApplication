import emailjs from '@emailjs/browser';

export const SendEmail = (data) => {
    return emailjs.send('service_hzpb31k', 'template_3szy0m6', {
        'sendername': 'MyPlantCare',
        'subject': data.subject,
        'message': data.message,
        'to': data.email
    }, 'Ti_V4VCd8trgJkDsh');
};