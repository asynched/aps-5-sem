import React from 'react'
import { useBox } from 'blackbox.js'

import { appBox } from '@/contexts/app'

import MessageFactory from './MessageFactory'

/**
 * # MessagesContainer
 *
 * Container for the UI messages.
 *
 * @returns { JSX.Element } A container for all the messages.
 */
export default function MessagesContainer() {
  const app = useBox(appBox)

  return (
    <div className="flex h-[calc(100%-5rem)] flex-col gap-4 overflow-y-auto overflow-x-hidden pt-6">
      <h1 className="text-4xl font-bold tracking-tighter">Messages</h1>
      {app.messages.map((message) => (
        <MessageFactory key={message.id} message={message} />
      ))}
    </div>
  )
}
