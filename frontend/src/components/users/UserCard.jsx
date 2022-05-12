import React from 'react'
import { motion } from 'framer-motion'

import { getUserImage } from '@/services/images'

/**
 * # UserCard
 *
 * A UI component for showing an user currently active in
 * the session chat.
 *
 * @param { Object } props Props for the component.
 * @returns { JSX.ELement } UI element for an active user.
 */
export default function UserCard({ user }) {
  return (
    <motion.div
      initial="hidden"
      animate="visible"
      exit="hidden"
      variants={{
        hidden: {
          x: -40,
          opacity: 0,
        },
        visible: {
          x: 0,
          opacity: 1,
        },
      }}
      className="flex items-center gap-4"
      key={user.id}
    >
      <div className="h-3 w-3 animate-pulse rounded-full bg-green-400"></div>
      <img
        className="h-8 w-8 rounded-full"
        src={getUserImage(user.name)}
        alt={user.name}
      />
      <span>{user.name}</span>
    </motion.div>
  )
}
